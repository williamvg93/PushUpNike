using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNike.Dtos.Get.BusinessMovements;
using AutoMapper;
using Domain.Entities.BusinessMovements;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiNike.Controller.BusinessMovements;

public class OrderstatusController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrderstatusController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<OrderstatusDto>>> Get()
    {
        var orderStates = await _unitOfWork.OrderStates.GetAllAsync();
        /* return Ok(orderStates); */
        return _mapper.Map<List<OrderstatusDto>>(orderStates);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<OrderstatusDto>> Get(int id)
    {
        var orderStatus = await _unitOfWork.OrderStates.GetByIdAsync(id);
        if (orderStatus == null)
        {
            return NotFound();
        }
        return _mapper.Map<OrderstatusDto>(orderStatus);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Orderstatus>> Post(OrderstatusDto orderstatusDto)
    {
        var orderStatus = _mapper.Map<Orderstatus>(orderstatusDto);

        this._unitOfWork.OrderStates.Add(orderStatus);
        await _unitOfWork.SaveAsync();
        if (orderStatus == null)
        {
            return BadRequest();
        }
        orderstatusDto.Id = orderStatus.Id;
        return CreatedAtAction(nameof(Post), new { id = orderstatusDto.Id }, orderstatusDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<OrderstatusDto>> Put(int id, [FromBody] OrderstatusDto orderstatusDto)
    {
        var orderStatus = _mapper.Map<Orderstatus>(orderstatusDto);
        if (orderStatus.Id == 0)
        {
            orderStatus.Id = id;
        }
        if (orderStatus.Id != id)
        {
            return BadRequest();
        }
        if (orderStatus == null)
        {
            return NotFound();
        }

        orderstatusDto.Id = orderStatus.Id;
        _unitOfWork.OrderStates.Update(orderStatus);
        await _unitOfWork.SaveAsync();
        return orderstatusDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var orderStatus = await _unitOfWork.OrderStates.GetByIdAsync(id);
        if (orderStatus == null)
        {
            return NotFound();
        }
        _unitOfWork.OrderStates.Remove(orderStatus);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}