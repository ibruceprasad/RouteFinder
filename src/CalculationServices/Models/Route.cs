using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteService.Models
{
    public record Route (string Start, string End, int Distance);
}
