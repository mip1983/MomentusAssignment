import { Component, OnInit } from '@angular/core';
import { PostListItem } from '../model/post';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
})
export class PostsComponent implements OnInit {

  constructor() {

  }

  displayedColumns: string[] = ['favorite', 'title', 'author', 'comments'];

  postsDataSource: MatTableDataSource<PostListItem> = new MatTableDataSource<PostListItem>();

  ngOnInit(): void {
    this.postsDataSource.data = [];
  }
}
