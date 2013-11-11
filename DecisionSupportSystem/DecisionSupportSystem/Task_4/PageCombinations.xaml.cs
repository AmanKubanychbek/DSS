﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using DecisionSupportSystem.MainClasses;

namespace DecisionSupportSystem.Task_4
{
    public partial class PageCombinations : Page
    {
        private BaseLayer _baseLayer;
        private NavigationService _navigation;
        private TaskCombinationsView localTaskLayer;

        public PageCombinations(BaseLayer baseLayer)
        {
            InitializeComponent();
            _baseLayer = baseLayer;
            localTaskLayer = new TaskCombinationsView(baseLayer);
            localTaskLayer.CreateCombinations();
            GrdCombinsLst.ItemsSource = localTaskLayer.CombinationWithParamViews;
        }

        private void BtnShowCombination_OnClick(object sender, RoutedEventArgs e)
        {
            GrdCombinsLst.Items.Refresh();
        }

        private void DataGridValidationError(object sender, ValidationErrorEventArgs e)
        {
           ErrorCount.CheckEntityListError(e);
        } 

        private void NextPage_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ErrorCount.EntityListErrorCount == 0;
            e.Handled = true;
        }

        private void NextPage_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _navigation = NavigationService.GetNavigationService(this);
            _navigation.Navigate(new PageSolve(_baseLayer, localTaskLayer));
        }

       private void BtnPrev_OnClick(object sender, RoutedEventArgs e)
        {
            _navigation = NavigationService.GetNavigationService(this);
            _navigation.Navigate(new PageEvents(_baseLayer));
        }
    }
}
