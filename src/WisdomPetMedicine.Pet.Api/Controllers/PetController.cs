﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WisdomPetMedicine.Pet.Api.ApplicationServices;
using WisdomPetMedicine.Pet.Api.Commands;

namespace WisdomPetMedicine.Pet.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PetController : ControllerBase
{
    private readonly PetApplicationService petApplicationService;
    private readonly ILogger<PetController> logger;

    public PetController(PetApplicationService petApplicationService,
                         ILogger<PetController> logger)
    {
        this.petApplicationService = petApplicationService;
        this.logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreatePetCommand command)
    {
        try
        {
            await petApplicationService.HandleCommandAsync(command);
            return Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("name")]
    public async Task<IActionResult> Put(SetNameCommand command)
    {
        try
        {
            await petApplicationService.HandleCommandAsync(command);
            return Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("breed")]
    public async Task<IActionResult> Put(SetBreedCommand command)
    {
        try
        {
            await petApplicationService.HandleCommandAsync(command);
            return Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("color")]
    public async Task<IActionResult> Put(SetColorCommand command)
    {
        try
        {
            await petApplicationService.HandleCommandAsync(command);
            return Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("dateofbirth")]
    public async Task<IActionResult> Put(SetDateOfBirthCommand command)
    {
        try
        {
            await petApplicationService.HandleCommandAsync(command);
            return Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("flagforadoption")]
    public async Task<IActionResult> Post(FlagForAdoptionCommand command)
    {
        try
        {
            await petApplicationService.HandleCommandAsync(command);
            return Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("transfertohospital")]
    public async Task<IActionResult> Post(TransferToHospitalCommand command)
    {
        try
        {
            await petApplicationService.HandleCommandAsync(command);
            return Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("/petinputbinding")]
    public async Task<IActionResult> OnInputBinding()
    {
        var command = await GetCommandFromRequest();
        await petApplicationService.HandleCommandAsync(command);
        return Ok();
    }

    private async Task<CreatePetCommand> GetCommandFromRequest()
    {
        using var streamReader = new StreamReader(Request.Body);
        var body = await streamReader.ReadToEndAsync();
        var bytes = Convert.FromBase64String(body);
        var decodedString = System.Text.Encoding.UTF8.GetString(bytes);
        var command = JsonConvert.DeserializeObject<CreatePetCommand>(decodedString);

        return command;
    }
}