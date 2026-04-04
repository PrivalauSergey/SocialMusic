import { Component } from '@angular/core';
import { MemberListComponent } from "./components/member-list/member-list.component";
import { ChatComponent } from "./components/chat/chat.component";
import { SongQueueComponent } from "./components/song-queue/song-queue.component";


@Component({
  standalone: true,
  selector: 'app-channel',
  templateUrl: './channel.component.html',
  styleUrl: './channel.component.scss',
  imports: [
    MemberListComponent,
    ChatComponent,
    SongQueueComponent
]
})
export class ChannelComponent {
  isOwner = true;
  channel = {
    name: 'Music Lovers',
    id: '123'
  };
}
