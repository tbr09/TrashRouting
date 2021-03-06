﻿using System;
using System.Collections.Generic;
using System.Text;
using TrashRouting.Common.Enums;

namespace TrashRouting.Common.Saga
{
    public interface ISagaState
    {
        string SagaId { get; }
        object Data { get; }
        SagaState State { get; }
        IEnumerable<Exception> Errors { get; }
    }
}
