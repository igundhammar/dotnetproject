import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomeComponent} from "./home/home.component";
import {AlbumComponent} from "./album/album.component";
import {NotfoundComponent} from "./notfound/notfound.component";
import {ArtistComponent} from "./artist/artist.component";

const routes: Routes = [
  {path: 'home', component: HomeComponent},
  {path: 'album', component: AlbumComponent},
  {path: 'artist', component: ArtistComponent},
  {path: '', redirectTo: 'home', pathMatch: 'full'},
  {path: '**', component: NotfoundComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
