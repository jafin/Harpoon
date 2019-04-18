﻿using System.Collections.Generic;

namespace Harpoon.Controllers.Models
{
    public class WebHookFilterDTO : IWebHookFilter
    {
        public string ActionId { get; set; }
        public Dictionary<string, object> Parameters { get; set; }

        IReadOnlyDictionary<string, object> IWebHookFilter.Parameters => Parameters;
    }
}