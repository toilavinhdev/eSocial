import { Component } from '@angular/core';
import { ChatContactsComponent } from '@app-features/feature-chat/chat-contacts/chat-contacts.component';
import { ChatMainComponent } from '@app-features/feature-chat/chat-main/chat-main.component';

@Component({
  selector: 'app-feature-chat',
  standalone: true,
  imports: [ChatContactsComponent, ChatMainComponent],
  templateUrl: './feature-chat.component.html',
  styles: ``,
})
export class FeatureChatComponent {}
