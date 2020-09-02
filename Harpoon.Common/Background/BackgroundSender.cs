﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Harpoon.Background
{
    internal class BackgroundSender : IWebHookSender
    {
        private readonly BackgroundQueue<IWebHookWorkItem> _webHooksQueue;

        public BackgroundSender(BackgroundQueue<IWebHookWorkItem> webHooksQueue)
        {
            _webHooksQueue = webHooksQueue ?? throw new ArgumentNullException(nameof(webHooksQueue));
        }

        public async Task SendAsync(IWebHookWorkItem webHookWorkItem, CancellationToken cancellationToken = default)
        {
            if (webHookWorkItem == null)
            {
                throw new ArgumentNullException(nameof(webHookWorkItem));
            }

            await _webHooksQueue.QueueWebHookAsync(webHookWorkItem);
        }
    }
}