﻿using BarControl.ProductModule;
using BarControl.Shared;
using System.Collections;

namespace BarControl.TableModule
{
    internal class TablePresentation : PresentationBase
    {
        public TablePresentation(TableRepository tableRepository)
        {
            repository = tableRepository;
            entityName = "Table";
        }

        protected override EntityBase GetRecordProperties()
        {
            string description = SetField<string>("Description:", ConsoleColor.Cyan);

            Table newTable = new Table(repository.idCounter, description);

            return newTable;
        }

        protected override void DisplayTable()
        {
            string[] columnNames = { "Num", "description" };
            int[] columnWidths = { 4, 50 };

            List<object> data = new List<object>();

            ArrayList records = repository.GetRecords();

            foreach (Table table in records)
            {
                data.Add(new object[] { table.id, table.Description });
            }

            SetTable(columnNames, columnWidths, data);

            SetFooter();
        }
    }
}