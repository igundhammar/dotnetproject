/**
 * Code generated and modified by Ida Gundhammar
 */
import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";

export class Album {
  constructor(
  public id: number,
  public name: string,
  public year: number,
  public genre: string,
  public artistName: string,
  public imagePath: string,
  ) {

  }
}

@Component({
  selector: 'app-album',
  templateUrl: './album.component.html',
  styleUrls: ['./album.component.scss']
})
export class AlbumComponent implements OnInit {
  searchText = '';
  albums!: Album[];

  constructor(
    private httpClient: HttpClient
  ) {

  }

  ngOnInit(): void {
    this.getAlbums();
  }


  getAlbums() {
    this.httpClient.get<any>('https://localhost:7240/api/album').subscribe(
      response => {
        this.albums = response;
      }
    )
  }
}
