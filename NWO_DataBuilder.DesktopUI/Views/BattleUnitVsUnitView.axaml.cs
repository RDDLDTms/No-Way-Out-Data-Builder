using Avalonia.Controls;
using Avalonia.ReactiveUI;
using NWO_DataBuilder.Core.ViewModels;

namespace NWO_DataBuilder.DesktopUI.Views
{
    public partial class BattleUnitVsUnitView : ReactiveWindow<BattleUnitVsUnitViewModel>
    {
        public BattleUnitVsUnitView()
        {
            InitializeComponent();
        }
    }
}
