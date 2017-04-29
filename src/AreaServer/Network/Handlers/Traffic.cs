﻿using Shared.Network;

namespace AreaServer.Network.Handlers
{
    class Traffic
    {

        [Packet(Packets.CmdUdpCastTcsSignal)]
        public static void UdpCastTcsSignal(Packet packet)
        {
            /*
              int m_AreaId;
              float m_x;
              float m_y;
              XiTCSSignal m_signal;

              int m_time;
              int m_signal;
              int m_state;
            */

            packet.Reader.ReadInt32(); // AreaId
            packet.Reader.ReadSingle(); // X
            packet.Reader.ReadSingle(); // Y

            var time = packet.Reader.ReadInt32(); // Time
            var signal = packet.Reader.ReadInt32(); // Signal
            var state = packet.Reader.ReadInt32(); // State

            var ack = new Packet(Packets.UdpCastTcsSignalAck);
            ack.Writer.Write(time);
            ack.Writer.Write(signal);
            ack.Writer.Write(state);
            AreaServer.Instance.Server.Broadcast(ack);
        }

        [Packet(Packets.CmdUdpCastTcs)]
        public static void UdpCastTcs(Packet packet)
        {
            
        }
    }
}

/*
  unsigned __int16 m_TrafficCarId;
  unsigned __int16 m_Owner;
  unsigned __int16 m_carAttr;
  unsigned __int16 m_path;
  XiVec4 m_Pos;
  XiVec4 m_Vel;
  int m_OwnTime;
  int m_dwGlobalTime;
  int m_FreedTime; 

    &pArea->m_spaceGrid,
      lpMsg->m_x,
      lpMsg->m_y,
      320.0,
      (CastTask<BS_PktTCSSignal> *)&param);
*/
