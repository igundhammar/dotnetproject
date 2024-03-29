import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AlbumComponent } from './album/album.component';
import { HomeComponent } from './home/home.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { HttpClientModule } from "@angular/common/http";
import { ArtistComponent } from './artist/artist.component';
import { FilterPipe} from "./search/filter.pipe";
import { FormsModule } from "@angular/forms";
import { Highlight } from "./search/highlight";
import { MatMenuModule } from '@angular/material/menu';
import {MatButtonModule} from "@angular/material/button";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";


@NgModule({
  declarations: [
    AppComponent,
    AlbumComponent,
    HomeComponent,
    NotfoundComponent,
    ArtistComponent,
    FilterPipe,
    Highlight,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    MatMenuModule,
    MatButtonModule,
    BrowserAnimationsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule {
}


