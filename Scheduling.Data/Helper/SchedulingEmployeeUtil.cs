using System;
using System.Collections.Generic;
using System.Text;
using Google.OrTools.LinearSolver;


namespace Scheduling.Data.Helper
{
    public class SchedulingEmployeeUtil
    {
        public int numEmp { get; set; }
        public int numShift { get; set; }
        public int[][] availability { get; set; }
       // public int[][] permanentEmployees { get; set; }
        public int[][] preference { get; set; }
        public int[][] rangeShiftForEachEmp { get; set; }
        public int[][] rangeEmpForEachShift { get; set; }

        public int[][] Schedule()
        {
            int[][] result = null;

            #region  Declare solver
            Solver solver = Solver.CreateSolver("SchedulingProgram", "GLOP");
            #endregion

            #region  Create the variables
            Variable[][] shifts = new Variable[numEmp][];
            for (int e = 0; e < numEmp; e++)
            {
                shifts[e] = new Variable[numShift];
                for (int s = 0; s < numShift; s++)
                {
                    if (availability[e][s] != 0)
                    {
                        shifts[e][s] = solver.MakeBoolVar($"n{e}s{s}");
                    }
                }
            }
            #endregion

            #region Define the constraints
            //Each shift have enough employee
            for (int s = 0; s < numShift; s++)
            {
                Constraint ct = solver.MakeConstraint(rangeEmpForEachShift[s][0], rangeEmpForEachShift[s][1]);
                for (int e = 0; e < numEmp; e++)
                {
                    if (shifts[e][s] != null)
                    {
                        ct.SetCoefficient(shifts[e][s], 1);
                    }
                }
            }

            //Each employee works least at rangeShiftForEachEmp[e][0] shift and most at rangeShiftForEachEmp[e][1] shift;
            for (int e = 0; e < numEmp; e++)
            {
                Constraint ct = solver.MakeConstraint(rangeShiftForEachEmp[e][0], rangeShiftForEachEmp[e][1]);
                for (int s = 0; s < numShift; s++)
                {
                    if (shifts[e][s] != null)
                    {
                        ct.SetCoefficient(shifts[e][s], 1);
                    }
                }
            }

            //Make permanent employees
            //for (int e = 0; e < numEmp; e++)
            //{
            //    for (int s = 0; s < numShift; s++)
            //    {
            //        if (permanentEmployees[e][s] == 1)
            //        {
            //            Constraint permanentConstraint = solver.MakeConstraint(1, 1);
            //            permanentConstraint.SetCoefficient(shifts[e][s], 1);
            //        }
            //    }
            //}

            #endregion

            #region Define the objective function
            // Optimization of Employee Satisfaction
            double[][] weightedArr = CalWeightedPrefer(availability, preference);
            Objective obj = solver.Objective();
            for (int e = 0; e < numEmp; e++)
            {
                for (int s = 0; s < numShift; s++)
                {
                    if (shifts[e][s] != null)
                    {
                        obj.SetCoefficient(shifts[e][s], weightedArr[e][s]);
                    }
                }
            }
            obj.SetMaximization();
            #endregion

            #region Invoke the solver and display the results
            Solver.ResultStatus status = solver.Solve();
            if (status != Solver.ResultStatus.INFEASIBLE)
            {
                result = new int[shifts.Length][];
                for (int e = 0; e < shifts.Length; e++)
                {
                    result[e] = new int[shifts[e].Length];
                    for (int s = 0; s < shifts[e].Length; s++)
                    {
                        result[e][s] = shifts[e][s] != null ? (int)shifts[e][s].SolutionValue() : 0;
                    }
                }
            }
            #endregion
            return result;
        }


        /// <summary>
        ///     Scheduling Algorithm with Optimization of Employee Satisfaction
        /// </summary>
        /// <remarks>
        ///     availability[i][j],
        ///     preference[i][j]
        ///         - i : Employee(starting at 0)
        ///         - j : Shift(starting at 0)
        /// </remarks>
        /// <param name="availability"></param>
        /// <param name="preference"></param>
        /// <returns>Returns a weighted shift matrix</returns>
        /// Reference: https://scheduling.philipithomas.com/scheduling.pdf
        /// Constraint ...
        public double[][] CalWeightedPrefer(int[][] availability, int[][] preference)
        {
            #region Constraints
            //3.1 - tổng số nhân viên available in shift >= tổng số nhân viên tối thiểu cần có in shift
            //3.2 - Mỗi nhân viên không được làm quá 2 shift mỗi 24 giờ
            //3.3 - Số shift tối thiểu nhân viên phải làm <= số shift nhân viên làm <= Số shift tối đa nhân viên có thể làm
            //3.4 - nhân viên availability shift mới có quyền prefer shift
            #endregion
            //Get size for loop
            int numEmployees = availability.Length;
            int numShifts = availability[0].Length;
            //Initialize matrix by copying availability
            double[][] weightedPreference = new double[availability.Length][];
            int numShiftPerDay = availability[0].Length;
            for (int i = 0; i < availability.Length; i++)
            {
                weightedPreference[i] = new double[numShiftPerDay];
                for (int j = 0; j < numShiftPerDay; j++)
                {
                    weightedPreference[i][j] = availability[i][j];
                }
            }

            //Loop through each employee
            for (int i = 0; i < numEmployees; i++)
            {
                int numAvailable = 0;
                int numPreferred = 0;
                //Count how many shifts they are available, and how many
                // they prefer
                for (int j = 0; j < availability[i].Length; j++)
                {
                    if (availability[i][j] == 1)
                    {
                        numAvailable++;
                    }
                }

                for (int j = 0; j < preference[i].Length; j++)
                {
                    if (preference[i][j] == 1)
                    {
                        numPreferred++;
                    }
                }

                if (numPreferred == 0 || numAvailable == numPreferred)
                {
                    // If they do not prefer any shifts, or if they prefer every shift
                    // The availability matrix weighting is correct (all 1s)
                }
                else
                {
                    //we upweights and downweights based on number of preferred shifts

                    //upweight calculation
                    double alpha = (double)(numAvailable - numPreferred) / numAvailable;
                    //downweight calculation
                    double beta = (double)(alpha * numPreferred) / (numAvailable - numPreferred);
                    //Loop through shifts and set weight
                    for (int j = 0; j < numShifts; j++)
                    {
                        if (availability[i][j] == 1 && preference[i][j] == 1)
                        {
                            //upweight shift
                            weightedPreference[i][j] = 1 + alpha;
                        }
                        else if (availability[i][j] == 1 && preference[i][j] == 0)
                        {
                            //downweight shift
                            weightedPreference[i][j] = 1 - beta;
                        }
                        else
                        {
                            //Already zero weight due to availability matrix
                            weightedPreference[i][j] = 0;
                        }
                    }
                }

            }

            return weightedPreference;
        }
    }
}
