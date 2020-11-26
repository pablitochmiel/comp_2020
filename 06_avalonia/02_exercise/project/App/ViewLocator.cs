// Copyright (c) The Avalonia Project. All rights reserved.
// Licensed under the MIT license. See licence.md file in the project root for full license information.

using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using App.ViewModels;

namespace App
{
    public class ViewLocator : IDataTemplate
    {
        public bool SupportsRecycling => false;

        public IControl Build(object data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            var name = data.GetType().FullName!.Replace("ViewModel", "View");
            var type = Type.GetType(name);

            if (type != null)
            {
                return (Control?) Activator.CreateInstance(type) ?? throw new ArgumentNullException(nameof(data));
            }

            return new TextBlock {Text = "Not Found: " + name};
        }

        public bool Match(object data)
        {
            return data is ViewModelBase;
        }
    }
}