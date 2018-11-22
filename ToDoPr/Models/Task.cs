using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoPr.Models
{
    public class Task
    {
        // ID задачи
        public int Id { get; set; }
        // Имя задачи
        public string TaskName { get; set; }
        // Имя исполнителя
        public string PerformerName { get; set; }
        // Выполнено ли
        public bool isDone { get; set; }
    }
}