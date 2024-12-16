﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuidingBlocks.CQRS
{
    public interface ICommand : ICommand<Unit>
    { }
    public interface ICommand<out TRespose> : IRequest<TRespose>
    {
    }
}
