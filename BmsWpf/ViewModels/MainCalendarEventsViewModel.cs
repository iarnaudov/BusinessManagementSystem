﻿namespace BmsWpf.ViewModels
{
    using System;
    using System.Data;
    using System.Windows;
    using System.Windows.Input;

    using BmsWpf.Behaviour;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Views.Forms;
    using MoreLinq;

    public class MainCalendarEventsViewModel:ViewModelBase,IPageViewModel
    {
        private DataTable calendarEvents;
        private DataRowView selectedCalendarEvents;

        public ICommand WindowLoadedCommand;
        public ICommand DoubleClickCommand;
        public ICommand AddNewCommand;
        public ICommand EditCommand;
        public ICommand DeleteCommand;
        public ICommand BackCommand;

        public ICalendarEventsService CalendarEventService { get; set; }
        //  public IInquiryService InquiryService { get; set; }
        public IViewManager ViewManager { get; set; }

        public Action CloseAction { get; set; }

        public string ViewName
        {
            get
            {
                return "Calendar Events";
            }
        }

        public DataRowView SelectedCalendarEvents
        {
            get
            {
                return this.selectedCalendarEvents;
            }
            set
            {
                this.selectedCalendarEvents = value;
                this.OnPropertyChanged(nameof(this.SelectedCalendarEvents));
            }
        }

        public DataTable CalendarEvents
        {
            get
            {
                return this.calendarEvents;
            }
            private set
            {
                this.calendarEvents = value;
                this.OnPropertyChanged(nameof(this.calendarEvents));
            }
        }

        public ICommand WindowLoaded
        {
            get
            {
                if (this.WindowLoadedCommand == null)
                {
                    this.WindowLoadedCommand = new RelayCommand(this.HandleLoadedCommand);
                }
                return this.WindowLoadedCommand;
            }
        }

        public ICommand DoubleClick
        {
            get
            {
                if (this.DoubleClickCommand == null)
                {
                    this.DoubleClickCommand = new RelayCommand(this.HandleEditCommand);
                }
                return this.DoubleClickCommand;
            }
        }

        public ICommand AddNew
        {
            get
            {
                if (this.AddNewCommand == null)
                {
                    this.AddNewCommand = new RelayCommand(this.HandleAddNewCommand);
                }
                return this.AddNewCommand;
            }
        }

        public ICommand Edit
        {
            get
            {
                if (this.EditCommand == null)
                {
                    this.EditCommand = new RelayCommand(this.HandleEditCommand);
                }
                return this.EditCommand;
            }
        }

        public ICommand Delete
        {
            get
            {
                if (this.DeleteCommand == null)
                {
                    this.DeleteCommand = new RelayCommand(this.HandleDeleteCommand);
                }
                return this.DeleteCommand;
            }
        }

        public ICommand Back
        {
            get
            {
                if (this.BackCommand == null)
                {
                    this.BackCommand = new RelayCommand(this.HandleBackCommand);
                }
                return this.BackCommand;
            }
        }

        private void HandleLoadedCommand(object parameter)
        {
            var calendarEventsDtos = CalendarEventService.GetMainCalendarEventsInfo();
            this.CalendarEvents = calendarEventsDtos.ToDataTable();
        }

        private void HandleAddNewCommand(object parameter)
        {
            var addNewCalendarEventWindow = this.ViewManager.ComposeObjects<CalendarEventForm>();
            addNewCalendarEventWindow.Show();
            this.CloseAction();
        }

        private void HandleEditCommand(object parameter)
        {
            if (this.SelectedCalendarEvents == null)
            {
                MessageBox.Show("Please select an event to continue");
                return;
            }
            var addNewCalendarEventWindow = this.ViewManager.ComposeObjects<CalendarEventForm>();
            var vm = (CalendarEventFormViewModel)addNewCalendarEventWindow.DataContext;
            vm.SelectedCalendarEvent = this.SelectedCalendarEvents;
            addNewCalendarEventWindow.Show();
            this.CloseAction();
        }

        private void HandleDeleteCommand(object parameter)
        {
            var calendarEventId = (int)this.selectedCalendarEvents.Row.ItemArray[0];

            var result = string.Empty;

            try
            {
                result = this.CalendarEventService.Delete(calendarEventId);
            }
            catch (Exception e)
            {
                result = e.Message;
            }

            MessageBox.Show(result);
        }

        private void HandleBackCommand(object parameter)
        {
            var mainWindow = this.ViewManager.ComposeObjects<MainWindow>();
            mainWindow.Show();
            this.CloseAction();
        }
    }
}