import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AlbumComponent } from './album/album.component';
import { HomeComponent } from './home/home.component';
import { NotfoundComponent } from './notfound/notfound.component';
import {HttpClientModule} from "@angular/common/http";
import { ArtistComponent } from './artist/artist.component';

@NgModule({
  declarations: [
    AppComponent,
    AlbumComponent,
    HomeComponent,
    NotfoundComponent,
    ArtistComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule {
}
