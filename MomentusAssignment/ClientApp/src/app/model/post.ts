export interface Post {
  userId: number;
  id: number;
  title: string;
  body: string;
}

export interface PostListItem {
  id: number;
  isFavorite: boolean;
  title: string;
  author: string;
  comments: number;
}
