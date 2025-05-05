import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';

interface Message {
  id: string;
  user: {
    id: string;
    name: string;
    avatar: string;
    role: string;
  };
  text: string;
  timestamp: Date;
  song?: {
    id: string;
    title: string;
    thumbnail: string;
    upvotes: number;
    downvotes: number;
  };
}

@Component({
  standalone: true,
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss'],
  imports: [CommonModule, FormsModule]
})
export class ChatComponent {
  @Input() channelId!: string;
  @Input() isOwner = false;
  
  newMessage = '';
  
  messages: Message[] = [
    {
      id: '1',
      user: {
        id: '1',
        name: 'Alex',
        avatar: 'https://i.pravatar.cc/40?img=1',
        role: 'owner'
      },
      text: 'Check out this song!',
      timestamp: new Date(),
      song: {
        id: 'song1',
        title: 'Bohemian Rhapsody',
        thumbnail: 'https://i.ytimg.com/vi/fJ9rUzIMcZQ/hqdefault.jpg',
        upvotes: 5,
        downvotes: 1
      }
    },
    {
      id: '2',
      user: {
        id: '2',
        name: 'Sam',
        avatar: 'https://i.pravatar.cc/40?img=2',
        role: 'moderator'
      },
      text: 'Great choice!',
      timestamp: new Date()
    }
  ];
  
  sendMessage() {
    if (!this.newMessage.trim()) return;
    
    this.messages.push({
      id: Date.now().toString(),
      user: {
        id: 'current-user',
        name: 'You',
        avatar: 'https://i.pravatar.cc/40?img=5',
        role: 'user'
      },
      text: this.newMessage,
      timestamp: new Date()
    });
    
    this.newMessage = '';
  }
  
  detectYoutubeUrl(event: ClipboardEvent) {
    const url = event.clipboardData?.getData('text');
    if (url?.includes('youtube.com')) {
      event.preventDefault();
      this.addSongFromUrl(url);
    }
  }
  
  addSongFromUrl(url: string) {
    this.messages.push({
      id: Date.now().toString(),
      user: {
        id: 'current-user',
        name: 'You',
        avatar: 'https://i.pravatar.cc/40?img=5',
        role: 'user'
      },
      text: 'Shared a song',
      timestamp: new Date(),
      song: {
        id: 'song' + Date.now(),
        title: 'New Song from URL',
        thumbnail: 'https://i.ytimg.com/vi/dQw4w9WgXcQ/hqdefault.jpg',
        upvotes: 0,
        downvotes: 0
      }
    });
  }
  
  vote(songId: string, type: 'up' | 'down') {
    const message = this.messages.find(m => m.song?.id === songId);
    if (message && message.song) {
      if (type === 'up') {
        message.song.upvotes++;
      } else {
        message.song.downvotes++;
      }
    }
  }
}