﻿using LeSportif.PageModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeSportif.Services.Navigation
{
    public interface INavigationService
    {
        /// <summary>
        /// Navigation method to asynchonously navigate between Page Models,
        /// and optionally pass navigation Data.
        /// </summary>
        /// <typeparam name="TPageModel"></typeparam>
        /// <param name="navigationData"></param>
        /// <returns></returns>
        Task NavigateToAsync<TPageModel>(object navigationData = null, bool setRoot = false)
            where TPageModel : PageModelBase;

        /// <summary>
        /// Pop navigation backstack
        /// </summary>
        /// <returns></returns>
        Task GoBackAsync();
    }
}
