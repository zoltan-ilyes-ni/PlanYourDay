﻿using System.Collections.Generic;
using System.Linq;
using POTD.DataService.Models;

namespace POTD.UI.ViewModels
{
    internal class TaskViewModel : ViewModelBase
    {
        private DayViewModel _day;
        private ProjectViewModel _project;
        public TimeViewModel _time;

        static TaskViewModel()
        {
            TimeValues = new List<TimeViewModel>
            {
                new TimeViewModel()
                {
                    DisplayValue = "0 Minutes",
                    Value = 0
                },
                new TimeViewModel()
                {
                    DisplayValue = "15 Minutes",
                    Value = 15
                },
                new TimeViewModel()
                {
                    DisplayValue = "30 Minutes",
                    Value = 30
                },
                new TimeViewModel()
                {
                    DisplayValue = "45 Minutes",
                    Value = 45
                },
                new TimeViewModel()
                {
                    DisplayValue = "1 Hour",
                    Value = 60
                },
                new TimeViewModel()
                {
                    DisplayValue = "1.5 Hours",
                    Value = 90
                },
                new TimeViewModel()
                {
                    DisplayValue = "2 Hours",
                    Value = 120
                },
                new TimeViewModel()
                {
                    DisplayValue = "2.5 Hours",
                    Value = 150
                },
                new TimeViewModel()
                {
                    DisplayValue = "3 Hours",
                    Value = 180
                },
                new TimeViewModel()
                {
                    DisplayValue = "3.5 Hours",
                    Value = 210
                },
                new TimeViewModel()
                {
                    DisplayValue = "4 Hours",
                    Value = 240
                }
            };
        }

        public TaskViewModel(TaskModel taskModel, DayViewModel dayViewModel, ProjectViewModel projectViewModel)
        {
            Day = dayViewModel;
            Project = projectViewModel;
            TaskModel = taskModel;
            // Todo: this will throw an exception if there is no match
            Time = TimeValues.First(t => t.Value == TaskModel.Time);
        }

        private TaskModel TaskModel { get; set; }

        public static List<TimeViewModel> TimeValues { get; private set; }

        public DayViewModel Day
        {
            get => _day;
            set => SetProperty(ref _day, value);
        }

        public bool Done
        {
            get => TaskModel.Done;
            set
            {
                if (TaskModel.Done != value)
                {
                    TaskModel.Done = value;
                    NotifyPropertyChanged(nameof(Done));
                }
            }
        }

        public string Name
        {
            get => TaskModel.Name;
            set
            {
                if (TaskModel.Name != value)
                {
                    TaskModel.Name = value;
                    NotifyPropertyChanged(nameof(Name));
                }
            }
        }

        public ProjectViewModel Project
        {
            get => _project;
            set => SetProperty(ref _project, value);
        }

        public int Rank
        {
            get => TaskModel.Rank;
            set => TaskModel.Rank = value;
        }

        public TimeViewModel Time
        {
            get => _time;
            set
            {
                if (_time != value)
                {
                    _time = value;
                    TaskModel.Time = _time.Value;
                    NotifyPropertyChanged(nameof(Time));
                    Day.NotifyPropertyChanged(nameof(Day.TimeString));
                }
            }
        }
    }
}