using System;
using System.Collections.Generic;

namespace LeetCodeGrapthProblems
{
    public class CourseScueduler
    {
        //Intutive Solution with Backtracking
        //This solution follows below algorithm
        //1. Build a graph from given array of courses
        //2. Traverse through graph using Backtracking and identify if there exist any cycles
        private Dictionary<int, List<int>> coursePrerequisireGraph = null;

        public CourseScueduler()
        {
            coursePrerequisireGraph = new Dictionary<int, List<int>>();
        }
        public bool canFinishWithBacktracking(int numCourses, int[][] prerequisite)
        {
            //Build graph from from given Course Prerequisite matrix
            BuildGraph(prerequisite);

            //Identify is course is already visited during traversal in graph
            bool[] isCourseVisited = new bool[numCourses];

            //Traverse through all the courses and check if requirement is fulfilled to complete all the courses from the graph
            for (int currCourse = 0; currCourse < numCourses; currCourse++)
            {
                //Identify if cycle is detected in the graph
                if(isCycleDetected(currCourse, coursePrerequisireGraph, isCourseVisited))
                    return false;
            }
            return true;

        }

        private bool isCycleDetected(int currCourseNumber, Dictionary<int, List<int>> coursePrerequisiteMap, bool[] isCourseCompleted)
        {
            //Current course is already visited and graph has a cycle detected
            if (isCourseCompleted[currCourseNumber])
                return true;

            //Current course isn't a part of curriculum to fulfill the requirement and so doesn't exist in the graph as well
            if (!coursePrerequisireGraph.ContainsKey(currCourseNumber))
                return false;

            //Mark course completed before starting traversal from that course
            isCourseCompleted[currCourseNumber] = true;

            //Initialize result to return for backtracking default to false
            bool isCycle = false;

            foreach (int nextCourse in coursePrerequisiteMap[currCourseNumber])
            {
                isCycle = isCycleDetected(nextCourse, coursePrerequisiteMap, isCourseCompleted);
                //Terminate backtracking when cycle is detected
                if (isCycle)
                    break;
            }

            //Remove the currentCourse from the visitedCourse list after backtracking
            isCourseCompleted[currCourseNumber] = false;
            return isCycle;
        }
        private void BuildGraph(int[][] prerequisiteCourseInput)
        {
            //Build Graph
            foreach (int[] courseDependency in prerequisiteCourseInput)
            {
                //Course[1] is a prerequisite of Course[0]
                //Store Prerequisites as Key and List of all the next courses follows
                //Single course can have a prerequisite of many next courses and so completing single course can open new branches of the graph
                if (!coursePrerequisireGraph.ContainsKey(courseDependency[1]))
                {
                    List<int> nextCourse = new List<int>();
                    nextCourse.Add(courseDependency[0]);
                    coursePrerequisireGraph.Add(courseDependency[1], nextCourse);
                }
                else
                {
                    //If preRequisite course number is already part of the mapping, add next course in the list
                    coursePrerequisireGraph[courseDependency[1]].Add(courseDependency[0]);
                }
            }
        }
    }
}
