// src/app/message/page.tsx
'use client';

import { useEffect, useState } from 'react';
import { fetchMessage } from '../../fetchMessage';

const MessagePage: React.FC = () => {
  const [message, setMessage] = useState<string | null>(null);

  useEffect(() => {
    const getMessage = async () => {
      try {
        const fetchedMessage = await fetchMessage();
        setMessage(fetchedMessage);
      } catch (error) {
        setMessage('Failed to fetch message.');
      }
    };

    getMessage();
  }, []);

  return (
    <div>
      <h1>Message from .NET Backend</h1>
      <p>{message || 'Loading...'}</p>
    </div>
  );
};

export default MessagePage;
