using EE.LiardKenny.BudgetApp.Models;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE.LiardKenny.BudgetApp.ViewModels
{
    public class DetailViewModel
        : FreshBasePageModel
    {
        public CashFlow CashFlow { get; set; }

        public bool IsCreate { get; set; }

        public override void Init(object initData)
        {
            base.Init(initData);

            if (initData != null)
            {
                CashFlow = initData as CashFlow;
                IsCreate = false;
            }
            else
            {
                CashFlow = new CashFlow
                {
                    DateOfTransaction = DateTime.Today
                };
                IsCreate = true;
            }
        }


    }
}
