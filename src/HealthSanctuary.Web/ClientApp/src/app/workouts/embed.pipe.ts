import { Pipe, PipeTransform } from '@angular/core';
import { DomSanitizer} from '@angular/platform-browser';

@Pipe({
  name: 'embed'
})
export class EmbedPipe implements PipeTransform {
  constructor(private sanitizer: DomSanitizer) {}

  transform(value: string, ...args: any[]): any {
    if (!value || !value.startsWith('https://www.youtube.com/')) {
      return this.sanitize('assets/video-placeholder.png');
    }

    const videoId = value.split('/').slice(-1).pop().slice(8);
    const videoUrl = `https://www.youtube.com/embed/${videoId}`;

    return this.sanitize(videoUrl);
  }

  sanitize(value: string) {
    return this.sanitizer.bypassSecurityTrustResourceUrl(value);
  }

}
