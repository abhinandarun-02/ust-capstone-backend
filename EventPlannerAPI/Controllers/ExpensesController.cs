using EventPlannerAPI.DTOs;
using EventPlannerAPI.Repositories.Services;
using Microsoft.AspNetCore.Mvc;
using EventPlannerAPI.Models;

namespace EventPlannerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpensesController(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        // POST: api/Expenses
        [HttpPost]
        public async Task<IActionResult> AddExpense([FromBody] ExpenseDTO expenseDTO)
        {
            if (string.IsNullOrEmpty(expenseDTO.Name) || expenseDTO.Cost <= 0)
            {
                return BadRequest(new Response{Message = "Invalid expense data provided."});
            }

            var success = await _expenseRepository.AddExpense(expenseDTO);
            if (!success)
            {
                return BadRequest(new Response{Message = "An error occurred. Couldn't add the expense."});
            }

            return Ok(new Response{Message = $"Expense '{expenseDTO.Name}' was successfully added."});
        }

        // GET: api/Expenses/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpenseById(int id)
        {
            var expense = await _expenseRepository.GetExpenseById(id);
            if (expense == null)
            {
                return NotFound(new Response{Message = $"Expense with id {id} was not found."});
            }

            return Ok(expense);
        }

        // GET: api/Expenses
        [HttpGet]
        public async Task<IActionResult> GetAllExpenses()
        {
            var expenses = await _expenseRepository.GetAllExpenses();
            if (!expenses.Any())
            {
                return NotFound(new Response{Message = "No expenses available."});
            }

            return Ok(expenses);
        }

        // DELETE: api/Expenses/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            var success = await _expenseRepository.DeleteExpense(id);
            if (!success)
            {
                return NotFound(new Response{Message = $"Expense with id {id} could not be found or deleted."});
            }

            return Ok(new Response{Message = $"Expense with id {id} was successfully deleted."});
        }

        // PUT: api/Expenses/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExpense(int id, [FromBody] ExpenseDTO expenseDTO)
        {
            if (string.IsNullOrEmpty(expenseDTO.Name) || expenseDTO.Cost <= 0)
            {
                return BadRequest(new Response{Message = "Invalid expense data provided."});
            }

            var success = await _expenseRepository.UpdateExpense(id, expenseDTO);
            if (!success)
            {
                return NotFound(new Response{Message = $"Expense with id {id} could not be found or updated."});
            }

            return Ok(new Response{Message = $"Expense with id {id} was successfully updated."});
        }
    }
}
