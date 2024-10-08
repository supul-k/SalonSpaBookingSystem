﻿using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalonSpaBookingSystem.DTO;
using SalonSpaBookingSystem.Interfaces.IServices;
using SalonSpaBookingSystem.Models;
using SalonSpaBookingSystem.Services;
using System.Security.Claims;

namespace SalonSpaBookingSystem.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly ISalonSpaService _salonSpaService;
        private readonly IServiceService _serviceService;

        public BookingController(
            IBookingService bookingService, 
            ISalonSpaService salonSpaService,
            IServiceService serviceService
            )
        {
            _bookingService = bookingService;
            _salonSpaService = salonSpaService;
            _serviceService = serviceService;
        }

        [HttpPost("create-booking", Name = "CreateBooking")]
        public async Task<IActionResult> CreateBooking([FromBody] BookingCreateRequestDTO request)
        {
            try
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized(new GeneralResposnseDTO(false, "User not authenticated"));
                }

                var salonSpaResult = await _salonSpaService.FindSalonSpa(request.SalonSpaId);
                if (!salonSpaResult.Status)
                {
                    return BadRequest(salonSpaResult);
                }

                var serviceResult = await _serviceService.FetchServiceById(request.ServiceId);
                if (!serviceResult.Status)
                {
                    return BadRequest(serviceResult);
                }

                var bookingResult = await _bookingService.IsBookingTimeAvailable(request.SalonSpaId, request.BookingDate, request.BookingTime);
                if (!bookingResult.Status)
                {
                    return BadRequest(bookingResult);
                }

                BookingModel booking = new BookingModel();
                booking.BookingId = Guid.NewGuid().ToString();
                booking.UserId = userId;
                booking.SalonSpaId = request.SalonSpaId;
                booking.ServiceId = request.ServiceId;
                booking.BookingDate = request.BookingDate;
                booking.BookingTime = request.BookingTime;
                booking.TotalPrice = request.TotalPrice;
                booking.Status = request.Status;
                booking.CreatedAt = DateTime.UtcNow;
                booking.UpdatedAt = DateTime.UtcNow;

                var result = await _bookingService.CreateBooking(booking);
                if (!result.Status)
                {
                    return BadRequest(result);
                }

                return Created(string.Empty, result);
            }
            catch (Exception ex)
            {
                return BadRequest(new GeneralResposnseDTO(false, ex.Message));
            }
        }

        [HttpPut("update-booking", Name = "UpdateBooking")]
        public async Task<IActionResult> UpdateBooking([FromBody] BookingUpdateRequestDTO request)
        {
            try
            {
                var bookingResult = await _bookingService.FindBooking(request.BookingId);
                if (!bookingResult.Status)
                {
                    return BadRequest(bookingResult);
                }

                BookingModel booking = bookingResult.Data as BookingModel;
                if (request.BookingDate.HasValue) booking.BookingDate = request.BookingDate.Value;
                if (request.BookingTime.HasValue) booking.BookingTime = request.BookingTime.Value;
                if (!string.IsNullOrEmpty(request.Status)) booking.Status = request.Status;
                if (request.TotalPrice.HasValue) booking.TotalPrice = request.TotalPrice.Value;
                booking.UpdatedAt = DateTime.UtcNow;

                var result = await _bookingService.UpdateBooking(booking);
                if (!result.Status)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new GeneralResposnseDTO(false, ex.Message));
            }
        }

        [HttpDelete("delete-booking/{bookingId}", Name = "DeleteBooking")]
        public async Task<IActionResult> DeleteBooking(string bookingId)
        {
            try
            {
                var bookingResult = await _bookingService.FindBooking(bookingId);
                if (!bookingResult.Status)
                {
                    return BadRequest(bookingResult);
                }

                var booking = bookingResult.Data as BookingModel;

                var result = await _bookingService.DeleteBooking(booking);
                if (!result.Status)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new GeneralResposnseDTO(false, ex.Message));
            }
        }

        [HttpGet("get-bookings", Name = "GetBookings")]
        public async Task<IActionResult> FetchBookings()
        {
            try
            {
                var result = await _bookingService.FetchBookings();
                if (!result.Status)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new GeneralResposnseDTO(false, ex.Message));
            }
        }

        [HttpGet("get-booking/{bookingId}", Name = "GetBookingById")]
        public async Task<IActionResult> FetchBookingById(string bookingId)
        {
            try
            {
                var result = await _bookingService.FindBooking(bookingId);
                if (!result.Status)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new GeneralResposnseDTO(false, ex.Message));
            }
        }

        [HttpGet("get-bookings-by-user", Name = "GetBookingByUserId")]
        public async Task<IActionResult> FetchBookingByUserId()
        {
            try
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized(new GeneralResposnseDTO(false, "User not authenticated"));
                }

                var result = await _bookingService.FetchBookingsByUserId(userId);
                if (!result.Status)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new GeneralResposnseDTO(false, ex.Message));
            }
        }
    }
}
