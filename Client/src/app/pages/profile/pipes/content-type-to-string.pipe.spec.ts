import { ContentTypeToStringPipe } from './content-type-to-string.pipe';

describe('ContentTypeToStringPipe', () => {
  it('create an instance', () => {
    const pipe = new ContentTypeToStringPipe();
    expect(pipe).toBeTruthy();
  });
});
