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

public class OrderController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrderController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<OrderDto>>> Get()
    {
        var orders = await _unitOfWork.Orders.GetAllAsync();
        /* return Ok(orders); */
        return _mapper.Map<List<OrderDto>>(orders);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<OrderDto>> Get(int id)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(id);
        if (order == null)
        {
            return NotFound();
        }
        return _mapper.Map<OrderDto>(order);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Order>> Post(OrderDto orderDto)
    {
        var order = _mapper.Map<Order>(orderDto);

        this._unitOfWork.Orders.Add(order);
        await _unitOfWork.SaveAsync();
        if (order == null)
        {
            return BadRequest();
        }
        orderDto.Id = order.Id;
        return CreatedAtAction(nameof(Post), new { id = orderDto.Id }, orderDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<OrderDto>> Put(int id, [FromBody] OrderDto orderDto)
    {
        var order = _mapper.Map<Order>(orderDto);
        if (order.Id == 0)
        {
            order.Id = id;
        }
        if (order.Id != id)
        {
            return BadRequest();
        }
        if (order == null)
        {
            return NotFound();
        }

        orderDto.Id = order.Id;
        _unitOfWork.Orders.Update(order);
        await _unitOfWork.SaveAsync();
        return orderDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(id);
        if (order == null)
        {
            return NotFound();
        }
        _unitOfWork.Orders.Remove(order);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}