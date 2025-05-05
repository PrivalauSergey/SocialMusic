import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';

@Component({
  standalone: true,
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrl: './member-list.component.scss',
  imports: [CommonModule]
})
export class MemberListComponent {
  @Input() isOwner = false;
  
  members = [
    { id: '1', name: 'Alex', avatar: 'https://i.pravatar.cc/40?img=1', role: 'owner' },
    { id: '2', name: 'Sam', avatar: 'https://i.pravatar.cc/40?img=2', role: 'moderator' },
    { id: '3', name: 'Jordan', avatar: 'https://i.pravatar.cc/40?img=3', role: 'user' }
  ];
  
  confirmDelete() {
    if (confirm('Delete this channel?')) {
      console.log('Channel deletion confirmed');
    }
  }
}
