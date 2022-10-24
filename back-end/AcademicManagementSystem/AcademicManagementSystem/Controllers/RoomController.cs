﻿using System.Text.RegularExpressions;
using AcademicManagementSystem.Context;
using AcademicManagementSystem.Context.AmsModels;
using AcademicManagementSystem.Handlers;
using AcademicManagementSystem.Models.RoomController.RoomModel;
using AcademicManagementSystem.Models.RoomController.RoomTypeModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcademicManagementSystem.Controllers;

[ApiController]
public class RoomController : ControllerBase
{
    private readonly AmsContext _context;

    private const string RegexRoomName = StringConstant.RegexVietNameseNameWithDashUnderscoreSpaces;

    public RoomController(AmsContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("api/rooms")]
    [Authorize(Roles = "admin")]
    public IActionResult GetRoomsByCenterId([FromQuery] int? centerId)
    {
        if (centerId != null && !IsCenterExists(centerId))
        {
            var error = ErrorDescription.Error["E0001"];
            return BadRequest(CustomResponse.BadRequest(error.Message, error.Type));
        }

        var roomsResponses = _context.Rooms
            .Include(r => r.Center)
            .Include(r => r.RoomType)
            .ToList();

        if (centerId != null)
        {
            roomsResponses = roomsResponses.Where(r => r.CenterId == centerId).ToList();
        }

        var responses = roomsResponses.Select(r => new RoomResponse()
        {
            Id = r.Id,
            CenterId = r.CenterId,
            CenterName = r.Center.Name,
            Room = new RoomTypeResponse()
            {
                Id = r.RoomTypeId,
                Value = r.RoomType.Value
            },
            Name = r.Name,
            Capacity = r.Capacity
        });

        return Ok(CustomResponse.Ok("Get all rooms by centerId successfully", responses));
    }

    //create new room
    [HttpPost]
    [Route("api/rooms")]
    [Authorize(Roles = "admin")]
    public IActionResult CreateRoom([FromBody] CreateRoomRequest createRoomRequest)
    {
        var roomCreate = new Room()
        {
            CenterId = createRoomRequest.CenterId,
            RoomTypeId = createRoomRequest.RoomTypeId,
            Name = createRoomRequest.Name.Trim(),
            Capacity = createRoomRequest.Capacity
        };

        roomCreate.Name = Regex.Replace(roomCreate.Name, StringConstant.RegexWhiteSpaces, " ");

        if (string.IsNullOrWhiteSpace(createRoomRequest.Name))
        {
            var error = ErrorDescription.Error["E0007"];
            return BadRequest(CustomResponse.BadRequest(error.Message, error.Type));
        }
        
        if (!Regex.IsMatch(roomCreate.Name, RegexRoomName))
        {
            var error = ErrorDescription.Error["E0008"];
            return BadRequest(CustomResponse.BadRequest(error.Message, error.Type));
        }
        
        if (IsRoomExists(roomCreate, false, 0))
        {
            var error = ErrorDescription.Error["E0003"];
            return BadRequest(CustomResponse.BadRequest(error.Message, error.Type));
        }

        if (createRoomRequest.Capacity < 20 || createRoomRequest.Capacity > 100)
        {
            var error = ErrorDescription.Error["E0006"];
            return BadRequest(CustomResponse.BadRequest(error.Message, error.Type));
        }

        _context.Rooms.Add(roomCreate);

        try
        {
            _context.SaveChanges();
        }
        catch (DbUpdateException)
        {
            var error = ErrorDescription.Error["E0005"];
            return BadRequest(CustomResponse.BadRequest(error.Message, error.Type));
        }

        var roomResponse = GetRoomResponse(roomCreate.Id);

        return Ok(CustomResponse.Ok("Create room successfully", roomResponse));
    }

    //Update room
    [HttpPut("api/rooms/{roomId:int}")]
    [Authorize(Roles = "admin")]
    public IActionResult UpdateRoom(int roomId, [FromBody] UpdateRoomRequest updateRoomRequest)
    {
        var roomToUpdate = _context.Rooms.FirstOrDefault(r => r.Id == roomId);
        if (roomToUpdate == null)
        {
            var error = ErrorDescription.Error["E0009"];
            return BadRequest(CustomResponse.BadRequest(error.Message, error.Type));
        }

        if (string.IsNullOrWhiteSpace(updateRoomRequest.Name))
        {
            var error = ErrorDescription.Error["E0010"];
            return BadRequest(CustomResponse.BadRequest(error.Message, error.Type));
        }

        if (!Regex.IsMatch(updateRoomRequest.Name.Trim(), RegexRoomName))
        {
            var error = ErrorDescription.Error["E0011"];
            return BadRequest(CustomResponse.BadRequest(error.Message, error.Type));
        }

        if (updateRoomRequest.Capacity < 20 || updateRoomRequest.Capacity > 100)
        {
            var error = ErrorDescription.Error["E0014"];
            return BadRequest(CustomResponse.BadRequest(error.Message, error.Type));
        }

        roomToUpdate.RoomTypeId = updateRoomRequest.RoomTypeId;
        roomToUpdate.Name = Regex.Replace(updateRoomRequest.Name.Trim(), StringConstant.RegexWhiteSpaces, " ");
        roomToUpdate.Capacity = updateRoomRequest.Capacity;

        if (IsRoomExists(roomToUpdate, true, roomId))
        {
            var error = ErrorDescription.Error["E0015"];
            return BadRequest(CustomResponse.BadRequest(error.Message, error.Type));
        }

        try
        {
            _context.SaveChanges();
        }
        catch (DbUpdateException)
        {
            var error = ErrorDescription.Error["E0005"];
            return BadRequest(CustomResponse.BadRequest(error.Message, error.Type));
        }

        var roomResponse = GetRoomResponse(roomToUpdate.Id);
        return Ok(CustomResponse.Ok("Update room successfully", roomResponse));
    }

    private bool IsRoomExists(Room room, bool isUpdate, int idUpdate)
    {
        if (isUpdate)
        {
            return _context.Rooms.Any(r =>
                r.CenterId == room.CenterId &&
                r.RoomTypeId == room.RoomTypeId &&
                r.Name == room.Name &&
                r.Id != idUpdate);
        }

        return _context.Rooms.Any(r =>
            r.CenterId == room.CenterId &&
            r.RoomTypeId == room.RoomTypeId &&
            r.Name == room.Name);
    }

    private bool IsCenterExists(int? centerId)
    {
        return _context.Centers.Any(e => e.Id == centerId);
    }

    private IQueryable<RoomResponse> GetRoomResponse(int roomId)
    {
        var roomResponse = _context.Rooms
            .Include(r => r.Center)
            .Include(r => r.RoomType)
            .Where(r => r.Id == roomId)
            .Select(r => new RoomResponse()
            {
                Id = r.Id,
                CenterId = r.CenterId,
                CenterName = r.Center.Name,
                Room = new RoomTypeResponse()
                {
                    Id = r.RoomTypeId,
                    Value = r.RoomType.Value
                },
                Name = r.Name,
                Capacity = r.Capacity
            });
        return roomResponse;
    }
}