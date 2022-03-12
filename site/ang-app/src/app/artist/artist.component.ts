import { Component, OnInit, Input } from '@angular/core';
import {HttpClient} from "@angular/common/http";

export class Artist {
  constructor(
    public name: string,
  ) {
  }
}

export class AlbumsOfArtist {
  constructor(
    public name: string,
  ) {
  }
}

@Component({
  selector: 'app-artist',
  templateUrl: './artist.component.html',
  styleUrls: ['./artist.component.scss']
})
export class ArtistComponent implements OnInit {
  @Input()

  artists!: Artist[];
  albumsOfArtist!: AlbumsOfArtist[];



  constructor(
    private httpClient: HttpClient,
  ) {

  }

  ngOnInit(): void {
    this.getArtists();
  }

  getArtists() {
    this.httpClient.get<any>('https://localhost:7240/api/artist').subscribe(
      response => {
        console.log(response);
        this.artists = response;
      }
    )
  }

  showAlbums(name : string) {
    this.httpClient.get<any>('https://localhost:7240/api/artist/' + name).subscribe(
      response => {
        console.log(response);
        this.albumsOfArtist = response;
      }
    );
  }

}
