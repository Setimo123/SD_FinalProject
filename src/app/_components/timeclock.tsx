/**
 * TimeClock Component
 * 
 * Displays the current time in 12-hour format with AM/PM.
 * Updates every second to show real-time.
 * 
 * Features:
 * - Client-side only rendering to avoid hydration mismatch
 * - Auto-updates every second
 * - Monospace font for consistent width
 * 
 * @component
 */

'use client';

import { useEffect, useState } from 'react';
import dayjs from 'dayjs';

/**
 * Real-time clock component
 * @returns Formatted time display (HH:MM:SS AM/PM)
 */
export default function TimeClock() {
  const [time, setTime] = useState('');
  const [mounted, setMounted] = useState(false);

  useEffect(() => {
    // Set mounted to avoid hydration mismatch
    setMounted(true);
    setTime(dayjs().format('hh:mm:ss A'));
    
    // Update time every second
    const interval = setInterval(() => {
      setTime(dayjs().format('hh:mm:ss A'));
    }, 1000);
    
    // Cleanup interval on unmount
    return () => clearInterval(interval);
  }, []);

  // Show placeholder until mounted (prevents hydration issues)
  if (!mounted) {
    return <p className="font-mono text-2xl text-white">--:--:-- --</p>;
  }

  return (
    <p className="font-mono text-2xl text-white">{time}</p>
  );
}