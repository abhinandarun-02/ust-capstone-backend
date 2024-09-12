using System;
using AutoMapper;
using EventPlannerAPI.Data;
using EventPlannerAPI.DTOs;
using EventPlannerAPI.Models;

namespace EventPlannerAPI.Repositories.Services;

public interface IExpenseRepository
{
    public Task<bool> AddExpense(ExpenseDTO expenseDto);
    public Task<bool> DeleteExpense(int id);
    public Task<bool> UpdateExpense(int id, ExpenseDTO expenseDto);
    public Task<ExpenseDTO> GetExpenseById(int id);
    public Task<IEnumerable<ExpenseDTO>> GetAllExpenses();
}
