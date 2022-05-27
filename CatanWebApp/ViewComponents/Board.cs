using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatanASP.ViewComponents
{
    public class Board : ViewComponent
    {
        private int _boardRadius;

        public Board(int boardRadius)
        {
            _boardRadius = boardRadius;
        }

        public async Task<IViewComponentResult> InvokeAsync(int maxPriority, bool isDone)
        {
            var items = await GetTilesAsync(maxPriority, isDone);
            return View(items);
        }
        private Task<List<TodoItem>> GetTilesAsync(int maxPriority, bool isDone)
        {
            return db.ToDo.Where(x => x.IsDone == isDone &&
                                 x.Priority <= maxPriority).ToListAsync();
        }
    }
}
