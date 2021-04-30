using System;

namespace Abstraction
{
    public interface IResponsive
    {
        Action OnChange { get; set; }
    }
}