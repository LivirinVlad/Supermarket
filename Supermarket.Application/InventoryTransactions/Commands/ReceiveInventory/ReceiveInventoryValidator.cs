using FluentValidation;
using Supermarket.Application.InventoryTransactions.Commands.SellInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.InventoryTransactions.Commands.ReceiveInventory;

public class SellInventoryValidator
    : AbstractValidator<SellInventoryCommand>
{
    public SellInventoryValidator()
    {
        RuleFor(x => x.Lines)
            .NotEmpty();

        RuleForEach(x => x.Lines)
            .ChildRules(line =>
            {
                line.RuleFor(x => x.ProductId)
                    .NotEmpty();

                line.RuleFor(x => x.Quantity)
                    .GreaterThan(0);
            });
    }
}
