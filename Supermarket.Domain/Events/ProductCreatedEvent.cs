using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Domain.Events;

public record ProductCreatedDomainEvent(Guid ProductId);
