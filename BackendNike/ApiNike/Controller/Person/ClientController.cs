using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNike.Dtos.Get.Person;
using AutoMapper;
using Domain.Entities.Person;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiNike.Controller.Person;

public class ClientController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ClientController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClientDto>>> Get()
    {
        var clients = await _unitOfWork.Clients.GetAllAsync();
        /* return Ok(clients); */
        return _mapper.Map<List<ClientDto>>(clients);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ClientDto>> Get(int id)
    {
        var client = await _unitOfWork.Clients.GetByIdAsync(id);
        if (client == null)
        {
            return NotFound();
        }
        return _mapper.Map<ClientDto>(client);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Client>> Post(ClientDto clientDto)
    {
        var client = _mapper.Map<Client>(clientDto);

        this._unitOfWork.Clients.Add(client);
        await _unitOfWork.SaveAsync();
        if (client == null)
        {
            return BadRequest();
        }
        clientDto.Id = client.Id;
        return CreatedAtAction(nameof(Post), new { id = clientDto.Id }, clientDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClientDto>> Put(int id, [FromBody] ClientDto clientDto)
    {
        var client = _mapper.Map<Client>(clientDto);
        if (client.Id == 0)
        {
            client.Id = id;
        }
        if (client.Id != id)
        {
            return BadRequest();
        }
        if (client == null)
        {
            return NotFound();
        }

        clientDto.Id = client.Id;
        _unitOfWork.Clients.Update(client);
        await _unitOfWork.SaveAsync();
        return clientDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var client = await _unitOfWork.Clients.GetByIdAsync(id);
        if (client == null)
        {
            return NotFound();
        }
        _unitOfWork.Clients.Remove(client);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}