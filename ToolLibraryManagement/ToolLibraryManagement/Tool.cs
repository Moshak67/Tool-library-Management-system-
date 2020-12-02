using System;
namespace ToolLibraryManagement
{
    class Tool
    {
        public int toolId;
        public string toolName;
        public string toolDescription;
        public int toolQuantity;
       // public int toolCount;

        public Tool()
        {
        }

        public Tool(int toolId, string toolName, string toolDescription, int toolQuantity)
        {
            this.toolId = toolId;
            this.toolName = toolName;
            this.toolDescription = toolDescription;
            this.toolQuantity = toolQuantity;
            //this.toolCount = toolCount;
        }

        public int ToolID
        {
            get { return toolId; }
        }

        public string ToolName
        {
            get { return toolName; }
        }

        public string ToolDescription
        {
            get { return toolDescription; }
        }

        public int ToolQuantity
        {
            get { return toolQuantity; }
        }

        //public int ToolCount
        //{
        //    get { return toolCount; }
        //}

        
    }

    class Category
    {
        public string categoryName;

        public Category(string categoryName)
        {
            this.categoryName = categoryName;
        }

        public string Name
        {
            get { return categoryName; }
        }
    }


}
