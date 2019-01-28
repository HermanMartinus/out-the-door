using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskMaster : MonoBehaviour {
    [System.Serializable]
    public struct Task
    {
        public string item;
        public bool completed;
    }

    public List<Task> tasks = new List<Task>();

    [SerializeField]
    Text textField;

    void Start () {
        PopulateTaskList();
    }
    
    public void CheckOff(string item)
    {
        List<Task> newTasks = new List<Task>();
        foreach (Task task in tasks)
        {
            Task newTask = task;
            if(task.item == item)
            {
                newTask.completed = true;
            }
            newTasks.Add(newTask);
        }
        tasks = newTasks;
        PopulateTaskList();
    }

    void PopulateTaskList()
    {
        textField.text = "To do:\n";
        foreach (Task task in tasks)
        {
            string completed = task.completed ? " (done)" : "";
            textField.text += task.item + completed + "\n";
        }
    }

    public bool IsCompleted()
    {
        foreach (Task task in tasks)
        {
            if(task.completed == false)
            {
                return false;
            }
        }
        return true;
    }

    private void Update()
    {
        transform.localScale = Vector2.Lerp(transform.localScale, Vector2.one, Time.deltaTime);
    }
}
