using FinanceManagementTool1.Data;
using FinanceManagementTool1.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Radzen;
using System.Linq;

namespace FinanceManagementTool1.Pages
{
    public partial class Dashboard
    {
        [Inject]
        private DialogService DialogService { get; set; }

        int selectedIndex = 0;

        private List<AddData> incomeData;
        private List<AddData> expenseData;

        protected override async Task OnInitializedAsync()
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            incomeData = await _context.AddData.Where(x => x.Amount > 0).ToListAsync();
            expenseData = await _context.AddData.Where(x => x.Amount < 0).ToListAsync();
        }

        private void OnAddTransactionClick()
        {
            Navigation.NavigateTo("/add-transaction");
        }

        private async Task OnDeleteTransactionClick(int id)
        {
            var confirmed = await DialogService.Confirm("Möchten Sie diese Transaktion wirklich löschen?", "Bestätigung",
            new ConfirmOptions { OkButtonText = "Ja", CancelButtonText = "Nein" });

            if (confirmed.HasValue && confirmed.Value)
            {
                var transaction = await _context.AddData.FindAsync(id);
                if (transaction != null)
                {
                    _context.AddData.Remove(transaction);
                    await _context.SaveChangesAsync();
                    await LoadDataAsync(); // Daten neu laden
                }
            }
        }
    }
    
}