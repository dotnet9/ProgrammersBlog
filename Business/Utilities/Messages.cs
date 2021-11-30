namespace Business.Utilities;

public static class Messages
{
	public static class Category
	{
		public static string NotFound(bool isPlural)
		{
			if (isPlural) return "未找到类别。";
			return "找不到这样的类别。";
		}

		public static string Add(string categoryName)
		{
			return $"{categoryName} 添加成功。";
		}

		public static string Update(string categoryName)
		{
			return $"{categoryName} 更新成功";
		}

		public static string Delete(string categoryName)
		{
			return $"{categoryName} 已被删除。";
		}

		public static string HardDelete(string categoryName)
		{
			return $"{categoryName} 从数据库中删除。";
		}

		public static string UndoDelete(string categoryName)
		{
			return $"{categoryName} 存档已成功撤消。";
		}
	}

	public static class Article
	{
		public static string NotFound(bool isPlural)
		{
			if (isPlural) return "未找到类别。";
			return "没有这样的文章。";
		}

		public static string Add(string articleTitle)
		{
			return $"{articleTitle} 添加成功。";
		}

		public static string Update(string articleTitle)
		{
			return $"{articleTitle} 更新成功。";
		}

		public static string Delete(string articleTitle)
		{
			return $"{articleTitle} 删除成功。";
		}

		public static string HardDelete(string articleTitle)
		{
			return $"{articleTitle} 从数据库中删除。";
		}

		public static string UndoDelete(string articleTitle)
		{
			return $"{articleTitle} 存档已成功撤消。";
		}

		public static string IncreaseViewCount(string articleTitle)
		{
			return $"{articleTitle} 标题中的文章数量已成功增加。";
		}
	}

	public static class Comment
	{
		public static string NotFound(bool isPlural)
		{
			if (isPlural) return "未找到类别。";
			return "没有这样的留言。";
		}

		public static string Approve(int commentId)
		{
			return $"审核 {commentId}, 评论被成功批准。";
		}

		public static string Add(string createdByName)
		{
			return $"计数 {createdByName}, 您的评论已成功添加。";
		}

		public static string Update(string createdByName)
		{
			return $"{createdByName} 作者添加的评论已成功更新。";
		}

		public static string Delete(string createdByName)
		{
			return $"{createdByName} 已成功删除它添加的评论。";
		}

		public static string HardDelete(string createdByName)
		{
			return $"{createdByName} 已成功删除数据库添加的评论。";
		}

		public static string UndoDelete(string createdByName)
		{
			return $"{createdByName} 已成功从存档中检索到由 所添加的评论。";
		}
	}
}