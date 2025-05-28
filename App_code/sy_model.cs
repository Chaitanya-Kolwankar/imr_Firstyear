using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

    public class sy_model
    {
        public string f_name { get; set; }
        public string m_name { get; set; }
        public string l_name { get; set; }
        public string mo_name { get; set; }
        public string dob { get; set; }
        public string mob_no { get; set; }
        public string prefaculty { get; set; }
        public string subcourse_name { get; set; }
        public string group_id { get; set; }
        public string passwd { get; set; }
        public string Out_of { get; set; }
        public string Marks_obtained { get; set; }
        public string Percentage { get; set; }
        public string ayid { get; set; }
        public string email_id { get; set; }
        public string seat_no { get; set; }
        public string pass_month { get; set; }
        public string pass_year { get; set; }
        public string is_diploma { get; set; }
        public string SEM_1 { get; set; }
        public string SEM_2 { get; set; }
        public string SEM_3 { get; set; }
        public string SEM_4 { get; set; }
        public string applicant_type { get; set; }
      

        public DataTable GenerateTransposedTable(DataTable inputTable)
        {
            DataTable outputTable = new DataTable();

            // Add columns by looping rows

            // Header row's first column is same as in inputTable
            outputTable.Columns.Add(inputTable.Columns[0].ColumnName.ToString());

            // Header row's second column onwards, 'inputTable's first column taken
            foreach (DataRow inRow in inputTable.Rows)
            {
                string newColName = inRow[0].ToString();
                outputTable.Columns.Add(newColName);
            }

            // Add rows by looping columns        
            for (int rCount = 1; rCount <= inputTable.Columns.Count - 1; rCount++)
            {
                DataRow newRow = outputTable.NewRow();

                // First column is inputTable's Header row's second column
                newRow[0] = inputTable.Columns[rCount].ColumnName.ToString();
                for (int cCount = 0; cCount <= inputTable.Rows.Count - 1; cCount++)
                {
                    string colValue = inputTable.Rows[cCount][rCount].ToString();
                    newRow[cCount + 1] = colValue;
                }
                outputTable.Rows.Add(newRow);
            }

            return outputTable;
        }
              
    }

