using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MyUnitConverter.ViewModels
{
    // Adds INotifyPropertyChanged (source generated)
	public abstract partial class ViewModelBase : ObservableObject
	{
        public INavigation? Navigation { get; set; }
    }
}

