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

public class OrderdetailController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrderdetailController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<OrderdetailDto>>> Get()
    {
        var orderDetails = await _unitOfWork.OrderDetails.GetAllAsync();
        /* return Ok(orderDetails); */
        return _mapper.Map<List<OrderdetailDto>>(orderDetails);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<OrderdetailDto>> Get(int id)
    {
        var orderDetail = await _unitOfWork.OrderDetails.GetByIdAsync(id);
        if (orderDetail == null)
        {
            return NotFound();
        }
        return _mapper.Map<OrderdetailDto>(orderDetail);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Orderdetail>> Post(OrderdetailDto orderdetailDto)
    {
        var orderDetail = _mapper.Map<Orderdetail>(orderdetailDto);

        this._unitOfWork.OrderDetails.Add(orderDetail);
        await _unitOfWork.SaveAsync();
        if (orderDetail == null)
        {
            return BadRequest();
        }
        orderdetailDto.Id = orderDetail.Id;
        return CreatedAtAction(nameof(Post), new { id = orderdetailDto.Id }, orderdetailDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<OrderdetailDto>> Put(int id, [FromBody] OrderdetailDto orderdetailDto)
    {
        var orderDetail = _mapper.Map<Orderdetail>(orderdetailDto);
        if (orderDetail.Id == 0)
        {
            orderDetail.Id = id;
        }
        if (orderDetail.Id != id)
        {
            return BadRequest();
        }
        if (orderDetail == null)
        {
            return NotFound();
        }

        orderdetailDto.Id = orderDetail.Id;
        _unitOfWork.OrderDetails.Update(orderDetail);
        await _unitOfWork.SaveAsync();
        return orderdetailDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var orderDetail = await _unitOfWork.OrderDetails.GetByIdAsync(id);
        if (orderDetail == null)
        {
            return NotFound();
        }
        _unitOfWork.OrderDetails.Remove(orderDetail);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}