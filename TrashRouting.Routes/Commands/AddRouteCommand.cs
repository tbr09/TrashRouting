﻿using TrashRouting.Common.Attributes;
using TrashRouting.Common.Contracts;

namespace TrashRouting.Routes.Commands
{
    [MessageNamespace("route")]
    public class AddRouteCommand : ICommand
    {
        public int Id { get; set; }
        public double StartLatitude { get; set; }
        public double StartLongitude { get; set; }
        public double TargetLatitude { get; set; }
        public double TargetLongitude { get; set; }
    }
}
