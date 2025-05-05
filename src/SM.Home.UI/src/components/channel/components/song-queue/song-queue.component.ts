import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';

interface Song {
  id: string;
  title: string;
  thumbnail: string;
  duration: string;
  upvotes: number;
  downvotes: number;
  addedBy: string;
}

@Component({
  standalone: true,
  selector: 'app-song-queue',
  templateUrl: './song-queue.component.html',
  styleUrls: ['./song-queue.component.scss'],
  imports: [CommonModule]
})
export class SongQueueComponent {
  @Input() channelId!: string;
  @Input() isOwner = false;
  
  currentSong: Song | null = {
    id: '1',
    title: 'Bohemian Rhapsody',
    thumbnail: 'https://i.ytimg.com/vi/fJ9rUzIMcZQ/hqdefault.jpg',
    duration: '5:55',
    upvotes: 5,
    downvotes: 1,
    addedBy: 'Alex'
  };
  
  queue: Song[] = [
    {
      id: '2',
      title: 'Sweet Child O\' Mine',
      thumbnail: 'https://i.ytimg.com/vi/1w7OgIMMRc4/hqdefault.jpg',
      duration: '5:56',
      upvotes: 3,
      downvotes: 0,
      addedBy: 'Sam'
    },
    {
      id: '3',
      title: 'Hotel California',
      thumbnail: 'https://i.ytimg.com/vi/BciS5krYL80/hqdefault.jpg',
      duration: '6:30',
      upvotes: 2,
      downvotes: 1,
      addedBy: 'Jordan'
    }
  ];
  
  isPlaying = true;
  
  togglePlayback() {
    this.isPlaying = !this.isPlaying;
  }
  
  vote(songId: string, type: 'up' | 'down') {
    // Handle case where currentSong might be null
    if (this.currentSong && this.currentSong.id === songId) {
      if (type === 'up') {
        this.currentSong.upvotes++;
      } else {
        this.currentSong.downvotes++;
      }
      return;
    }

      // Handle queue songs
    const song = this.queue.find(s => s.id === songId);
    if (song) {
      if (type === 'up') {
        song.upvotes++;
      } else {
        song.downvotes++;
      }
      this.sortQueue();
    }
  }
  
  sortQueue() {
    this.queue.sort((a, b) => {
      const aScore = a.upvotes - a.downvotes;
      const bScore = b.upvotes - b.downvotes;
      return bScore - aScore;
    });
  }
  
  removeSong(songId: string) {
    this.queue = this.queue.filter(s => s.id !== songId);
  }
  
  moveSong(songId: string, direction: 'up' | 'down') {
    const index = this.queue.findIndex(s => s.id === songId);
    if (index === -1) return;
    
    const newIndex = direction === 'up' ? index - 1 : index + 1;
    if (newIndex < 0 || newIndex >= this.queue.length) return;
    
    [this.queue[index], this.queue[newIndex]] = [this.queue[newIndex], this.queue[index]];
  }
}