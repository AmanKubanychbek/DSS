﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using DecisionSupportSystem.DbModel;
using DecisionSupportSystem.CommonClasses;

namespace DecisionSupportSystem
{
    public class LoadedTask
    {
        public List<Task> Tasks { get; set; }

        public void LoadTasks(string taskUniq)
        {
            Tasks = new List<Task>();
            try
            {
                using (var dssDbContext = new DssDbEntities())
                {
                    var tasks = (from task in dssDbContext.Tasks
                                 where task.TaskUniq == taskUniq && task.Deleted != 1
                                 select task).ToList();
                    foreach (var t in tasks)
                        Tasks.Add(t);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось подключиться к базе данных.");
            }
            
        }
    }

    public partial class SolvedTasksPage
    {
        public LoadSolvedTask Layer { get; set; }
        public SavedTasksViewModel TaskViewForSolvedTaskWindow { get; set; }

        public SolvedTasksPage(SavedTasksViewModel taskViewForSolvedTaskWindow)
        {
            InitializeComponent();
            TaskViewForSolvedTaskWindow = taskViewForSolvedTaskWindow;
            txtbTaskName.Text = taskViewForSolvedTaskWindow.Name;
            RefreshTable();
        }

        private void Download_Click(object sender, RoutedEventArgs e)
        {
            if (gridTasks.SelectedItem != null)
            {
                Layer = new LoadSolvedTask((Task)gridTasks.SelectedItem);
                Layer.AddCombinationsToCurrentDssDbEntities();
                var asm = Assembly.GetExecutingAssembly();
                var task = asm.GetType(TaskViewForSolvedTaskWindow.Window);
                object taskInstance = Activator.CreateInstance(task);
                MethodInfo methodInfo = task.GetMethod("InitBaseLayerAndShowMainPage");
                methodInfo.Invoke(taskInstance, new object[] {TaskViewForSolvedTaskWindow.Name, TaskViewForSolvedTaskWindow.TaskUniq, Layer.currentDssDbEntities });
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshTable();
        }  
        
        private void RefreshTable()
        {
            var loadedTask = new LoadedTask();
            loadedTask.LoadTasks(TaskViewForSolvedTaskWindow.TaskUniq);
            gridTasks.ItemsSource = loadedTask.Tasks;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (gridTasks.SelectedItem != null)
            {
                using (DssDbEntities context = new DssDbEntities())
                {
                    var tasks = context.Tasks.Select(t => t);
                    tasks.Where(t => t.Id == ((Task) gridTasks.SelectedItem).Id).Select(t => t).First().Deleted = 1;
                    context.SaveChanges();
                    RefreshTable();
                }
            }

        }
    }
}
