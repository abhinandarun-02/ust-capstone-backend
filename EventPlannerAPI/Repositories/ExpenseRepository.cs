using AutoMapper;
using EventPlannerAPI.Data;
using EventPlannerAPI.DTOs;
using EventPlannerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlannerAPI.Repositories.Services
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly EventPlannerDbContext _context;
        private readonly IMapper _mapper;

        public ExpenseRepository(EventPlannerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddExpense(ExpenseDTO expenseDto)
        {
            var expense = _mapper.Map<Expense>(expenseDto);
            await _context.Expenses.AddAsync(expense);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteExpense(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null) return false;

            _context.Expenses.Remove(expense);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateExpense(int id, ExpenseDTO expenseDto)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null) return false;

            _mapper.Map(expenseDto, expense);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<ExpenseDTO> GetExpenseById(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            return _mapper.Map<ExpenseDTO>(expense);
        }

        public async Task<IEnumerable<ExpenseDTO>> GetAllExpenses()
        {
            var expenses = await _context.Expenses.ToListAsync();
            return _mapper.Map<IEnumerable<ExpenseDTO>>(expenses);
        }
    }
}
