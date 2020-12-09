namespace TestDemo
{
	using System;
	using System.Drawing;
	using System.Threading;

    using AForge.Video;

	public class Camera
	{
        //定义借口变量
		private IVideoSource	videoSource = null;
		private Bitmap			lastFrame = null;
        private string          lastVideoSourceError = null;

		// 图像信息
		private int width = -1;
        private int height = -1;

		// 公共事件句柄
		public event EventHandler NewFrame;
        public event EventHandler VideoSourceError;

        // 最后视频帧
		public Bitmap LastFrame
		{
			get { return lastFrame; }
		}

        // Last video source error
        public string LastVideoSourceError
        {
            get { return lastVideoSourceError; }
        }

		// 视频帧宽度属性
		public int Width
		{
			get { return width; }
		}

		//视频帧高度属性
		public int Height
		{
			get { return height; }
		}

		// Frames received from the last access to the property
		public int FramesReceived
		{
			get { return ( videoSource == null ) ? 0 : videoSource.FramesReceived; }
		}

        // Bytes received from the last access to the property
		public int BytesReceived
		{
			get { return ( videoSource == null ) ? 0 : videoSource.BytesReceived; }
		}

		// Running property
		public bool IsRunning
		{
			get { return ( videoSource == null ) ? false : videoSource.IsRunning; }
		}

		// Constructor
        public Camera( IVideoSource source )
		{
			this.videoSource = source;
			videoSource.NewFrame += new NewFrameEventHandler( video_NewFrame );
            videoSource.VideoSourceError += new VideoSourceErrorEventHandler( video_VideoSourceError );

           
		}

		// 打开视频
		public void Start( )
		{
			if ( videoSource != null )
			{
                
				videoSource.Start( );
			}
		}

		// 发送停止信号
		public void SignalToStop( )
		{
			if ( videoSource != null )
			{
				videoSource.SignalToStop( );
            }
		}

		// 等待视频停止
		public void WaitForStop( )
		{
			// lock
			Monitor.Enter( this );

			if ( videoSource != null )
			{
				videoSource.WaitForStop( );
			}
			// unlock
			Monitor.Exit( this );
		}

		// 摄像停止
		public void Stop( )
		{
			// lock
			Monitor.Enter( this );

			if ( videoSource != null )
			{
				videoSource.Stop( );
			}

			// unlock
			Monitor.Exit( this );
		}

		// 锁定
		public void Lock( )
		{
			Monitor.Enter( this );
		}

		// 解除锁定
		public void Unlock( )
		{
			Monitor.Exit( this );
		}

		// 新图像帧
		private void video_NewFrame( object sender, NewFrameEventArgs e )
		{
			try
			{
				// lock
				Monitor.Enter( this );

				// 释放旧图像帧
				if ( lastFrame != null )
				{
					lastFrame.Dispose( );
				}

                // 复位
                lastVideoSourceError = null;
                // 得到新图像
				lastFrame = (Bitmap) e.Frame.Clone( );
                // 图像信息
				width = lastFrame.Width;
				height = lastFrame.Height;
            }
			catch ( Exception )
			{
			}
			finally
			{
				// unlock
				Monitor.Exit( this );
			}

			// notify client
			if ( NewFrame != null )
				NewFrame( this, new EventArgs( ) );
		}

        // On video source error
        private void video_VideoSourceError( object sender, VideoSourceErrorEventArgs e )
        {
            // save video source error's description
            lastVideoSourceError = e.Description;

            // notify clients about the error
            if ( VideoSourceError != null )
            {
                VideoSourceError( this, new EventArgs( ) );
            }
        }

      
	}
}
